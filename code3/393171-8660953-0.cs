    public SomeHub : Hub
    {
        public void RandomAction()
        {
            if(!CheckCookie("Role Required"))
            {
                //In here we have what happens when there is
                //  a cookie that is associated with the right Role Required
            }
        }
    }
