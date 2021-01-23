                int unitTypeId = (this.grdUnitTypes.SelectedItem as UnitType).ID;
                ConfirmWindowResult result = Helpers.ShowConfirm(this, SR.GlobalMessages.AreYouSureToDelete, SR.GlobalMessages.Warning);
                if (result == ConfirmWindowResult.Yes)
                {
                    using (AccountingEntities cntx = new AccountingEntities())
                    {
                        try
                        {
                            cntx.UnitTypes.DeleteObject(cntx.UnitTypes.First(x => x.ID == unitTypeId));
                            cntx.SaveChanges();
                            dataPager.Source = cntx.UnitTypes.ToList();
                            MessageBox.Show("Success");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error");
                        }
                        finally
                        {
                            cntx.Dispose();
                        }
                    }
                }
