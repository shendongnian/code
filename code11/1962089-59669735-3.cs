        int i = 0;
        while(i + 1 < usernameandpassword.Length)
        {
            if(username == usernameandpassword[i] && password == usernameandpassword[i+1])
            {
                userfound = true;
                break;
            }
            i+=2;
        }
