    lock(whatever)
    {
        try
        {
            MakeAMess();
        }
        finally
        {
            CleanItUp();
            // Either by completing the operation or rolling it back 
            // to the pre-mess state
        }
    }
