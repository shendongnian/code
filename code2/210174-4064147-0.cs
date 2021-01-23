        void button1_Click(object sender, EventArgs e)
        {
            Class1 c = new Class1();
            Action action = c.Test;
            action.BeginInvoke(new AsyncCallback(EndTestMethod), null);
        }
        void EndTestMethod(IAsyncResult token)
        {    
            Action callBack = (Action)((AsyncResult)token).AsyncDelegate;
            callBack.EndInvoke(token);
        }
