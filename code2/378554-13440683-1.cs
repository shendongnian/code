            DateTime present = DateTime.Now;
            DateTime addFiveSeconds = DateTime.Now.AddSeconds(10);
            while (DateTime.Now.TimeOfDay.TotalSeconds <= addFiveSeconds.TimeOfDay.TotalSeconds)
            {
                this.Status = TransactionStatus.Pending;
                
            }  
            b.Debit(amount);
            this.Status = TransactionStatus.Complete; 
