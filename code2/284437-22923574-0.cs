     MessageQueue msgQueue = null;
            string queuePath = ".\\Private$\\billpay";
            Payment newPayment = new Payment()
            {
                Payee = txtPayee.Text,
                Payor = txtPayor.Text,
                Amount = Convert.ToInt32(txtAmount.Text),
                DueDate = dpDueDate.SelectedDate.Value.ToShortDateString()
            };
            Message msg = new Message();
            msg.Body = newPayment;
            msg.Label = "Gopala - Learning Message Queue";
            
            if (MessageQueue.Exists(queuePath) == false)
            {
                //Queue doesnot exist so create it
                msgQueue = MessageQueue.Create(queuePath);
            }
            else
            {
                msgQueue = new MessageQueue(queuePath);
            }            
            msgQueue.Send(msg);
