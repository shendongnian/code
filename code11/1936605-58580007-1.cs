    public void GoBackMain()
            {
                if (dgvCariRehber.CurrentRow.Index != -1)
                {
                    cariModel.Id = Convert.ToInt32(dgvCariRehber.CurrentRow.Cells["Id"].Value);
                    using (fastCellDb db = new fastCellDb())
                    {
                        cariModel = db.xcaSabits.Where(x => x.Id == cariModel.Id).FirstOrDefault();
                        originalForm.CariID = cariModel.Id;
                        originalForm.CariKodu = cariModel.cariKodu;
                        originalForm.CariAdi = cariModel.cariIsim;
                        originalForm.CariPopulate();
                        this.Close();
                    }
                }
            }
