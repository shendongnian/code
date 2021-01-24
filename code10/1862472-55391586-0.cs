    public  class MyActionMesageFilter:ActionMessageFilter
    {
        public MyActionMesageFilter(params string[] actions):base(actions)
        {
        }
      
        public override bool Match(Message message)
        {
            string mes = message.ToString();
            bool re = base.Match(message);
           string action = message.Headers.Action;
            return  re;
        }
    }
