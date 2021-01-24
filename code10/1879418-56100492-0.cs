                    MessageBox.Show("Nominal yang dibayarkan lebih kecil dari Subtotal!");
                }
                else
                {
                    openConnection();
                    string selectQuery = "SELECT * FROM data_pegawai WHERE is_deleted=0 AND username='" + user + "'";
                    MySqlCommand command1 = new MySqlCommand(selectQuery, conn);
                    MySqlDataReader reader1 = command1.ExecuteReader();
                    while (reader1.Read())
                    {
                        id = reader1.GetInt32("id_peg");
                    }
                    closeConnection();
                    kembali = bayar - subtotal;
                    lblKembali.Text = kembali.ToString();
                    string insertQuery1 = "UPDATE data_transaksi SET status_pengerjaan='Lunas',potongan_harga='" + diskonrupiah.ToString() + "',subtotal='" + txtSubtotal.Text + "' WHERE id_transaksi =" + int.Parse(txtID_T.Text);
                    string insertQuery2 = "INSERT INTO pegawai_onduty VALUES(NULL, '" + id + "','" + txtID_T.Text + "')";
                    openConnection();
                    string selectQuery1 = "SELECT dsp.id_spareparts, dtsp.JUMLAH_SPAREPART from data_transaksi dt LEFT JOIN detail_transaksi_sparepart dtsp ON dt.id_transaksi=dtsp.id_transaksi LEFT JOIN spareparts_motor sm ON dtsp.ID_SPAREPARTMOTOR=sm.ID_SPAREPARTMOTOR LEFT JOIN data_spareparts dsp ON sm.id_spareparts=dsp.id_spareparts where dtsp.id_transaksi =" + int.Parse(txtID_T.Text);
                    MySqlCommand command2 = new MySqlCommand(selectQuery1, conn);
                    MySqlDataReader reader2 = command2.ExecuteReader();
                    while (reader2.Read())
                    {
                        idSparepart = reader2.GetString(0);
                        jmlJual = reader2.GetInt32(1);
                    }
                    closeConnection();
                    openConnection();
                    string getData = "SELECT jumlah_stok FROM data_spareparts dsp WHERE id_spareparts='" + idSparepart + "'";
                    MySqlCommand command3 = new MySqlCommand(getData, conn);
                    MySqlDataReader reader3 = command3.ExecuteReader();
                    while (reader3.Read())
                    {
                        jmlStok = reader3.GetInt32(0);
                    }
                    closeConnection();
                    sisastok = jmlStok - jmlJual;
                    string updateStok = "UPDATE data_spareparts SET jumlah_stok = '" + sisastok + "' WHERE id_spareparts ='" + idSparepart + "'";
                    try
                    {
                        openConnection();
                        MySqlCommand command4 = new MySqlCommand(updateStok, conn);
                        if (command4.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Data berhasil disimpan!");
                        }
                        else
                        {
                            MessageBox.Show("Data tidak berhasil disimpan!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        closeConnection();
                    }
                    runQuery(insertQuery1);
                    runQuery(insertQuery2);
                    loadTransaksi();
                }
