            private void ProcessIntent(Intent intent)
            {
                var LabelNFCTag = FindViewById<TextView>(Resource.Id.textNFCTag);
    
                try
                {
                    nfcTag = intent.GetParcelableExtra(NfcAdapter.ExtraTag) as Tag;
    
                    if (nfcTag != null)
                    {
                        // First get all the NdefMessage
                        var messages = intent.GetParcelableArrayExtra(NfcAdapter.ExtraNdefMessages);
                        if (messages != null)
                        {
                            var msg = (NdefMessage)messages[0];
    
                            // Get NdefRecord which contains the actual data
                            var record = msg.GetRecords()[0];
                            if (record != null)
                            {
                                if (record.Tnf == NdefRecord.TnfWellKnown) // The data is defined by the Record Type Definition (RTD) specification available from http://members.nfc-forum.org/specs/spec_list/
                                {
                                    // Get the transfered data
                                    var data = Encoding.ASCII.GetString(record.GetPayload());
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LabelNFCTag.Text = $"{newLine} Exeption:{newLine}{ex.Message}{newLine}{ex.StackTrace}";
                }
            }
