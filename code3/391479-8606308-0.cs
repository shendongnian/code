                    if (!(e.Item.DataItem is GridInsertionObject))
                    {
                        _participantList.SelectedValue =
                            ((ReinsuranceAgreementParticipant) (e.Item.DataItem)).LegacyReinsurerID.ToString();
                        // I added this line
                        _participantList.Text = ((ReinsuranceAgreementParticipant)(e.Item.DataItem)).LegacyReinsurerID.ToString();
                    }
                    if (e.Item.DataItem is GridInsertionObject)
                        _participantList.EmptyMessage = "Select Reinsurer";
