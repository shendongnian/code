        [Serializable]
    	[MulticastAttributeUsage(MulticastTargets.Class, AllowMultiple=false, Inheritance = MulticastInheritance.Multicast)]
    	public class PostConstructorAttribute : InstanceLevelAspect {
    
    		private Type _classType;
    
    		public override void CompileTimeInitialize(Type type, AspectInfo aspectInfo) {
    			//Assign the class type to the _classType variable,
    			//At compile time this will always be the type of the class we are currently in.
    			_classType = type;
    			
    			base.CompileTimeInitialize(type, aspectInfo);
    		}
    
    		[OnMethodExitAdvice, MulticastPointcut(MemberName = ".ctor")]
    		public void OnExit(MethodExecutionArgs args)
    		{
    			//Instance is the top most type of the hierarchy, 
    			//so if _classType is the top most type then we are in the top most constructor!
    			if (Instance.GetType() == _classType) {
    				//We are at the top most constructor and after all constructors have been called.
    				//Everything is setted up now and we can safely use virtual functions
    
    				//Magic happens here!
    			}
    		}
    	}
