        class A {
            [ThreadStatic]
            public int a;
        }
        [Test]
        public void Try() {
            var a1 = new A();
            var a2 = new A();
            a1.a = 5;
            a2.a = 10;
            a1.a.Should().Be.EqualTo(5);
            a2.a.Should().Be.EqualTo(10);
        }
