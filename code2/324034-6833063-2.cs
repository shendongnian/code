    public class Foo {
        public Foo(Foo other) {
            this.Id = other.Id;
            this.Bar = other.Bar;
        }
        public Foo() { }
        public int Id { get; set; } 
        public string Bar { get; set; }
    }
    public static void Test() {
        var foo = new Foo { Id = 1, Bar = "blah" };
        var newFoo = new Foo(foo) { Bar = "boo-ya" };
        Console.WriteLine(newFoo.Bar);
    }
