    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace MyNameSpace
    {
        /// <summary>
        /// Interface for C++ DLL. This exposes the functions used inside the dll
        /// Make sure the return types, function names, and argument types match the class
        /// </summary>
        [ComVisible(true)]
        [Guid("CBA208F2-E43B-4958-97C7-C24EA5A213DE")]
        public interface IMyClass
        {
            int Function1();
            int Function2();
        }
    
        [ClassInterface(ClassInterfaceType.None)]
        [Guid("579091E6-83A1-4aa5-89A7-F432AB2A57E3")]
        [ComVisible(true)]
        public class MyClass : IMyClass
        {
            public MyClass()
            {
                //Constructor
            }
    
           public int Function1()
            {
                //Do something in C#
    
                return an integer;
            }
    
            public int Function2()
            {
                //Do something else in C#
    
                return an integer;
            }
        }//End Class MyClass
    }//End namespace MyNameSpace
