       if ((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
        {
                //
                //Select By EventID Operation.
                //
                //Also, use Convert.ToString() rather than .ToString();
                eventID = int.Parse(Convert.ToString(dgvEvents.Rows[dgvEvents.CurrentRow.Index].Cells["EventID"].Value));
                EventEntity = EventsMethods.SelectByID(eventID);
                txtEventName.Text = EventEntity.Name;
                cboxEventsCategories.SelectedValue = EventEntity.EventCategoryID;
                dateTimePickerEvent.Text = EventEntity.Date.ToString();
                txtBenefNum.Text = EventEntity.BeneficiariesNumber.ToString();
                txtResultB.Text = EventEntity.ResultBefore.ToString();
                txtResultA.Text = EventEntity.ResultAfter.ToString();
                txtPercentage.Text = EventEntity.Percentage.ToString();
                //
                //Show EventsMembers.
                //
                FillEventsMembersDGV();
        }
