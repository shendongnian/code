    TelephonyManager tMgr = (TelephonyManager)getSystemService(Context.TELEPHONY_SERVICE);
            String MyPhoneNumber = "0000000000";
            try
            {
                MyPhoneNumber = tMgr.getLine1Number();
            }
            catch (NullPointerException ex)
            {
            }
            if (MyPhoneNumber.equals(""))
            {
                MyPhoneNumber = tMgr.getSubscriberId();
            }
