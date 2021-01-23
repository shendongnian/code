    System.TypeInitializationException occurred
      HResult=-2146233036
      Message=The type initializer for 'Microsoft.Web.Deployment.DeploymentManager' threw an exception.
      Source=Microsoft.Web.Deployment
      TypeName=Microsoft.Web.Deployment.DeploymentManager
      StackTrace:
           at Microsoft.Web.Deployment.DeploymentManager.GetLinkExtensions()
           at Microsoft.Web.Deployment.DeploymentBaseOptions..ctor()
           at SimpleTest.Test.UnitTest1.TestMethod1() in f:\Source\Projects\SimpleTest.Test\UnitTest1.cs:line 12
      InnerException: System.TypeInitializationException
           HResult=-2146233036
           Message=The type initializer for 'Microsoft.Web.Deployment.BuiltInTypesCache' threw an exception.
           Source=Microsoft.Web.Deployment
           TypeName=Microsoft.Web.Deployment.BuiltInTypesCache
           StackTrace:
                at Microsoft.Web.Deployment.BuiltInTypesCache.get_Factories()
                at Microsoft.Web.Deployment.DeploymentProviderFactoryCollection.LoadFromRegistry()
                at Microsoft.Web.Deployment.DeploymentProviderFactoryCollection..ctor()
                at Microsoft.Web.Deployment.DeploymentManager.LoadDeploymentManagerSettings()
                at Microsoft.Web.Deployment.DeploymentManager..cctor()
           InnerException: Microsoft.Web.Deployment.DeploymentException
                HResult=-2146233088
                Message=The provider 'Microsoft.Data.Tools.Schema.MsDeploy.MsDeployProviderFactory' could not be loaded.
                Source=Microsoft.Web.Deployment
                StackTrace:
                     at Microsoft.Web.Deployment.DeploymentProviderFactory.Create(Type type)
                     at Microsoft.Web.Deployment.BuiltInTypesCache.InspectTypesForWebDeployAttributes(IEnumerable`1 types, String dllName)
                     at Microsoft.Web.Deployment.BuiltInTypesCache..cctor()
                InnerException: Microsoft.Web.Deployment.DeploymentException
                     HResult=-2146233088
                     Message=The type 'Microsoft.Data.Tools.Schema.MsDeploy.MsDeployProviderFactory' could not be loaded. The configuration settings may not be valid.
                     Source=Microsoft.Web.Deployment
                     StackTrace:
                          at Microsoft.Web.Deployment.ReflectionHelper.CreateInstance[T](Type type, Object[] constructorArguments)
                          at Microsoft.Web.Deployment.DeploymentProviderFactory.Create(Type type)
                     InnerException: System.TypeInitializationException
                          HResult=-2146233036
                          Message=The type initializer for 'Microsoft.Data.Tools.Schema.MsDeploy.MsDeployProviderBaseProviderFactory' threw an exception.
                          Source=mscorlib
                          TypeName=Microsoft.Data.Tools.Schema.MsDeploy.MsDeployProviderBaseProviderFactory
                          StackTrace:
                               at System.Runtime.Remoting.RemotingServices.AllocateUninitializedObject(RuntimeType objectType)
                               at System.Runtime.Remoting.Activation.ActivationServices.CreateInstance(RuntimeType serverType)
                               at System.Runtime.Remoting.Activation.ActivationServices.IsCurrentContextOK(RuntimeType serverType, Object[] props, Boolean bNewObj)
                               at System.RuntimeTypeHandle.CreateInstance(RuntimeType type, Boolean publicOnly, Boolean noCheck, Boolean& canBeCached, RuntimeMethodHandleInternal& ctor, Boolean& bNeedSecurityCheck)
                               at System.RuntimeType.CreateInstanceSlow(Boolean publicOnly, Boolean skipCheckThis, Boolean fillCache, StackCrawlMark& stackMark)
                               at System.RuntimeType.CreateInstanceDefaultCtor(Boolean publicOnly, Boolean skipCheckThis, Boolean fillCache, StackCrawlMark& stackMark)
                               at System.Activator.CreateInstance(Type type, Boolean nonPublic)
                               at System.RuntimeType.CreateInstanceImpl(BindingFlags bindingAttr, Binder binder, Object[] args, CultureInfo culture, Object[] activationAttributes, StackCrawlMark& stackMark)
                               at System.Activator.CreateInstance(Type type, BindingFlags bindingAttr, Binder binder, Object[] args, CultureInfo culture, Object[] activationAttributes)
                               at System.Activator.CreateInstance(Type type, Object[] args)
                               at Microsoft.Web.Deployment.ReflectionHelper.CreateInstance[T](Type type, Object[] constructorArguments)
                          InnerException: System.IO.FileNotFoundException
                               HResult=-2147024894
                               Message=Could not load file or assembly 'Microsoft.Data.Tools.Schema.Sql, Version=10.3.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The system cannot find the file specified.
                               Source=Microsoft.Data.Tools.Schema.DbSqlPackage
                               FileName=Microsoft.Data.Tools.Schema.Sql, Version=10.3.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
                               FusionLog=""
                               StackTrace:
                                    at Microsoft.Data.Tools.Schema.MsDeploy.MsDeployProviderBaseProviderFactory..cctor()
                               InnerException:
