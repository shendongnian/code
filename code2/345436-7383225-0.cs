        class Class1
        {
            public delegate void AnimationEndHandler();
            public event AnimationEndHandler AnimationEnded;
            public void Animation()
            {
                //do the animation
                Console.WriteLine("Animation ended. This is class 1");
                AnimationEnded();
            }
        }
        class Class2
        {
            public Class2(Class1 c1)
            {
                c1.AnimationEnded += new Class1.AnimationEndHandler(DoSomethingOnAnimationEnd);
            }
            public void DoSomethingOnAnimationEnd()
            {
                Console.WriteLine("Animation ended. This is class 2");
            }
        }
        static void Main(string[] args)
        {
            Class1 c1 = new Class1();
            Class2 c2 = new Class2(c1);
            c1.Animation();
        }
