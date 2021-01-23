    public class RecursiveBuildUpContainerExtension : UnityContainerExtension {
    		protected override void Initialize(){
    			Context.Strategies.Add( new RecursiveBuildUpBuilderStrategy( Context.Container ), UnityBuildStage.PreCreation );
    		}
    	}
    
    	public class RecursiveBuildUpBuilderStrategy : BuilderStrategy {
    		readonly IUnityContainer container;
    		public RecursiveBuildUpBuilderStrategy( IUnityContainer container ) {
    			this.container = container;
    		}
    
    		public override void PreBuildUp( IBuilderContext context ) {
    
    			if( context.Existing == null ) return;
    
    			foreach( var prop in context.Existing.GetType( ).GetProperties( ) ) {
    
    				if( ContainsType<DependencyAttribute>( prop.GetCustomAttributes( true ) ) ) {
    
    					if( prop.GetValue( context.Existing, null ) == null ) {
    						var value = container.Resolve( prop.GetType( ) );
    						prop.GetSetMethod( ).Invoke( context.Existing, new[] { value } );
    					}
    					else {
    						var value = container.BuildUp( prop.PropertyType, prop.GetValue( context.Existing, null ) );
    						prop.GetSetMethod( ).Invoke( context.Existing, new[] { value } );
    					}
    				}
    			}
    			
    			foreach (var method in context.Existing.GetType().GetMethods() ){
    				if( ContainsType<InjectionMethodAttribute>( method.GetCustomAttributes( true ))){
    					var argsInfo = method.GetParameters( );
    					var args = new object[argsInfo.Length];
    
    					for( int i = 0; i < argsInfo.Length; i++ ) {
    						args[i] = container.Resolve( argsInfo[i].ParameterType );
    					}
    
    					method.Invoke( context.Existing, args );
    				}
    			}
    
    			context.BuildComplete = true;
    		}
    
    		private static bool ContainsType<T>( IEnumerable<object> objects ){
    			foreach (var o in objects){
    				if( o is T ) return true;
    			}
    			return false;
    		}
    
    	}
