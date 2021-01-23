    using System;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Threading;
    
    namespace ReflectPerversely
    {
    	class SuicidallyWrong
    	{
    		private static ModuleBuilder mb;
    		public static Assembly ResolveEvent(Object sender, ResolveEventArgs args)
    		{
    			return mb.Assembly;
    		}
    		public static void Main(string[] args)
    		{
    			Assembly sys = Assembly.GetAssembly(typeof(string));
    			Type ic = sys.GetType("System.CurrentSystemTimeZone",true);
    			AssemblyName an = new AssemblyName();
    			an.Name = "CheatingInternal";
    			AssemblyBuilder ab = Thread.GetDomain().DefineDynamicAssembly(an, AssemblyBuilderAccess.RunAndSave);
    			mb = ab.DefineDynamicModule("Mod", "CheatingInternal.dll");
    			AppDomain currentDom = Thread.GetDomain();
    			currentDom.TypeResolve += ResolveEvent;
    			
    			TypeBuilder tb = mb.DefineType("Cheat", TypeAttributes.NotPublic | TypeAttributes.Class, ic);
    			
    			Type cheatType = tb.CreateType();
    		}
    	}
    }
