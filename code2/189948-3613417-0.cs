    class Class1
    {
        private Form1 _Instance = null;
        public Form1 Instance
        {
            get{return _Instance;}
            set{_Instance = value;}
        }
        public void cl()
        {
            if(Instance == null)
            {
                try
                {
                    Instance = new Form1();
                }catch (SomeException e)
                {
                    //Log e.ToString();
                    return;
                }
            }
            Instance.textBox1.Text = "hiya";
        }
    }
