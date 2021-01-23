        ....................
        interface IOne
        {
           void MethodOne();
        }
        interface ITwo
        {
            void MethodTwo();
        }
        interface IThree
        {
            void MethodThree();
        }
        class TestIf : IOne, ITwo, IThree
        {
            void IThree.MethodThree()
            {
                MessageBox.Show("Method three");                
            }
            void IOne.MethodOne()
            {
                MessageBox.Show("Method one");
            }
            void ITwo.MethodTwo()
            {
                MessageBox.Show("Method two");
            }
        }
        ...................
        private void button1_Click(object sender, EventArgs e)
        {
            TestIf t = new TestIf();
            IOne one = t as IOne;
            ITwo two = t as ITwo;
            IThree three = t as IThree;
            one.MethodOne();
            two.MethodTwo();
            three.MethodThree();
        }
