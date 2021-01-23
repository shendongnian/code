    using System;
    using System.ComponentModel;
    
    [DefaultProperty("Aardvark")]
    class MyFoo : Component {
        public MyFoo() { }
        public MyFoo(IContainer container) { container.Add(this); }
    
        [DefaultValue(0)]
        public int Aardvark { get; set; }
    }
