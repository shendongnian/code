        foreach (GridViewRow GVRow in GridView1.Rows)
        {
            Name = GVRow.Cells[1].Text;
            CarType = GVRow.Cells[2].Text;
            TechnicalNo = GVRow.Cells[3].Text;
            ProductionDate = GVRow.Cells[4].Text;
            EngaineType = GVRow.Cells[5].Text;
            NoInStock = GVRow.Cells[6].Text;
            NoForCar = GVRow.Cells[7].Text;
            Price = GVRow.Cells[8].Text;
            Image = GVRow.Cells[9].Text;
            Desc = GVRow.Cells[10].Text;
            PartType = GVRow.Cells[11].Text;
            Level = GVRow.Cells[12].Text;
            Unit = GVRow.Cells[13].Text;
            Ratio = GVRow.Cells[14].Text;
            Dirham = GVRow.Cells[15].Text;
            ExtraMoney = GVRow.Cells[16].Text;
         
        SqlConnection scn = new SqlConnection(clspublic.GetConnectionString());
     using(con)
     {  
        SqlCommand scm = new SqlCommand();
        scm.Connection = scn;
        scm.CommandText = @"INSERT INTO tblProduct
                          (fName, fxCarType, fProductionDate, fEngineType, fNoinStock, fNoforCar, fPrice,fRatio,fDirham,fExtraMoney, fImage, fDesc, fxPartType, fxLevel,fUnitType,fTechnicalNo)
               VALUES     (@fName,@fxCarType,@fProductionDate,@fEngineType,@fNoinStock,@fNoforCar,@fPrice,@fRatio,@fDirham,@fExtraMoney,@fImage,@fDesc,@fxPartType,@fxLevel,@fUnitType,@fTechnicalNo)";
        scm.Parameters.AddWithValue("@fName", Name.ToString());
        scm.Parameters.AddWithValue("@fxCarType", CarType.ToString());
        scm.Parameters.AddWithValue("@fTechnicalNo", TechnicalNo.ToString());
        scm.Parameters.AddWithValue("@fProductionDate", ProductionDate.ToString());
        scm.Parameters.AddWithValue("@fEngineType", EngaineType.ToString());
        scm.Parameters.AddWithValue("@fNoinStock", NoInStock.ToString());
        scm.Parameters.AddWithValue("@fNoforCar", NoForCar.ToString());
        scm.Parameters.AddWithValue("@fPrice", Price.ToString());
        scm.Parameters.AddWithValue("@fRatio", Ratio.ToString());
        scm.Parameters.AddWithValue("@fDirham", Dirham.ToString());
        scm.Parameters.AddWithValue("@fExtraMoney", ExtraMoney.ToString());
        scm.Parameters.AddWithValue("@fImage", Image.ToString());
        scm.Parameters.AddWithValue("@fDesc", Desc.ToString());
        scm.Parameters.AddWithValue("@fxPartType", PartType.ToString());
        scm.Parameters.AddWithValue("@fUnitType", Unit.ToString());
        scm.Parameters.AddWithValue("@fxLevel", Level.ToString());
       scm.ExecuteNonQuery();
     }
   }
