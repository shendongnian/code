        public class MyTableAdapter2 : MyTableAdapter
        {
            public MyTableAdapter2()
            {
                SqlCommand[] cmds = base.CommandCollection;
                // here, the IDS parameter is index 0 of command 1
                // you'll have to be more clever, but you get the idea
                cmds[1].Parameters[0].TypeName = "MyIntArray";
            }
        }
