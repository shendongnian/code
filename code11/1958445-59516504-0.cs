    public delegate void FUNLoginMsgCB(int nMsg, Form1 form1);
    ....
    ....
    [DllImport("libnetclient.dll", CallingConvention = CallingConvention.StdCall)]
    public static extern int NETCLIENT_RegLoginMsg(Form1 form1, FUNLoginMsgCB _callback);
    private void loginbutton_Click(object sender, EventArgs e)
    {
      var _callback = new FUNLoginMsgCB(DoLoginMsgCB);
      NETCLIENT_RegLoginMsg(this, _callback);//call the callback function
    }
    private static void DoLoginMsgCB(int nMsg, Form1 form1)
     {
       switch (nMsg)//switch shows result after login function called
        {
          case 0:
              MessageBox.Show("LOGIN_SUC");
              break;
          case 1:
              MessageBox.Show("LOGIN_FAILED");
              break;
          case 2:
              MessageBox.Show("LOGIN_DISCNT");
              break;
          case 3:
              MessageBox.Show("LOGIN_NAME_ERR");
              break;
          default:
              MessageBox.Show("DEFAULT");               
              break;
       }
    }
