        [Test]
        public void Test()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IBreakfast>().To<Eggs>();
            kernel.Bind<IBreakfast>().To<Spam>();
            kernel.Bind<IBreakfast>().To<MoreSpam>();
            var bling = kernel.Get<Bling>();
        }
        private class Bling
        {
            public Bling(List<IBreakfast> things)
            {
                things.ForEach(t => t.Eat());
            }
        }
        private interface IBreakfast
        {
            void Eat();
        }
        private class Ingrediant : IBreakfast
        {
            public void Eat(){Console.WriteLine(GetType().Name);}
        }
        private class Eggs : Ingrediant{}
        private class Spam : Ingrediant{}
        private class MoreSpam : Ingrediant { }
