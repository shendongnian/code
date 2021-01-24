    class Cx : C2
    {
        protected override void M1()
        {
            base.M1();//i.e. C2.M1()
            //Cx.M1 internal logic
        }
    }
