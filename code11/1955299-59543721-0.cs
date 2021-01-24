    using System;
    using System.ComponentModel.DataAnnotations;
    
    namespace Foo.Model
    {
        public class FooEntity
        {
            [MaxLength(500)]
            public string FooName { get; set; }
        }
    }
