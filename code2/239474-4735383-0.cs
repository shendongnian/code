        private static void RunTest(Action<IThing1> test)
        {
            RunTest(test: (thing1, thing2, thing3) => test(thing1));
        }
        private static void RunTest(Action<IThing1, IThing2> test)
        {
            RunTest(test: (thing1, thing2, thing3) => test(thing1, thing2));
        }
        private static void RunTest(Action<IThing1, IThing2, IThing3> test)
        {
            IThing1 thing1 = new Mock<IThing1>().Object;
            IThing2 thing2 = new Mock<IThing2>().Object;
            IThing3 thing3 = new Mock<IThing3>().Object;
            test(thing1, thing2, thing3);
        }
        [Test]
        public void do_some_stuff_to_a_thing()
        {
            RunTest(test: thing1 => {
                //Do some testing....
            });
        }
        [Test]
        public void do_some_stuff_to_things()
        {
            RunTest(test: (thing1, thing2) => {
                //Do some testing....
            });
        }
