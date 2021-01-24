    2.1. Define a Module for your add Uwp project  (Add>NewItem>PhoneBookDemoXamarinUwpModule.cs):
         using Abp.Modules;
         using Abp.Reflection.Extensions;
           namespace Acme.PhoneBookDemo
           {
               [DependsOn(typeof(PhoneBookDemoXamarinSharedModule))]
                  public class PhoneBookDemoXamarinUwpModule : AbpModule
                  {
                    public override void Initialize()
                    {     IocManager.RegisterAssemblyByConvention(typeof(PhoneBookDemoXamarinUwpModule).GetAssembly());
                    }
                }
            }
     In the initialize method above we register dependencies , IocManager is used to register the module class.
