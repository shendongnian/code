    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace controllertest
    {
        public interface IController<T>
        {
            void functionwrapper(T master);
            void initialize();
            T getobj(IController<T> master);
        }
    }
