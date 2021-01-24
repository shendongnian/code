    private void TimerCheckInternetConnection_Tick(object sender, EventArgs e)
        {
            #region Check whether the users have internet connection or not
            if (Components.Check_Internet_For_Acceptation() == Status.NoConnection)
            {
                // your logic for no connection
            } else if(Components.Check_Internet_For_Acceptation() == Status.Connected)
            {
                //your logic for connected
            }
            //else status is unknown and nothing will happen till it is connected or no connection
                TimerCheckInternetConnection.Enabled = false;
            }
            #endregion
        }
