    public void computing()
        {
           //THIS PART MUST RUN ON THE MAIN THREAD, DON'T MAKE IT ON THE OTHER THREAD
           //IT IS A MUST
            int count = 0;
            //THIS IS THE LONG TIME COMPUTING THING
            for (int i = 0; i < 100; i++)
            {
                count += i;
                updateLabel(count);
                Thread.Sleep(2000);
                Application.DoEvents(); //tell windows to process pending message.
            }
        }
