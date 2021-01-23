        lock ( _db.Messages )
        {
            var newRow = _db.Messages.NewMessagesRow();
            {
                newRow.Title = title;
                newRow.Text = text;
                newRow.ReceiverUID = receiverUID;
                newRow.Deleted = false;
            }
            _db.Messages.AddMessagesRow( newRow );
            _adapterMessages.Connection.Open();
            _adapterMessages.Update( newRow );
            newRow.MessageID = (Int64)_adapterMessages.GetIdentity();
            newRow.AcceptChanges();
            _adapterMessages.Connection.Close();
        }
