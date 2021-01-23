            //Your original Table Which consist of Data
            DataTable dtProducts = new DataTable();
            //Add the DataTable to DataView
            DataView ProductDataView = new DataView(dtProducts);
            ProductDataView.RowFilter = "";
            ProductDataView.Sort = "ProdId";
            int recordIndex = -1;
            //In the Find Row Method pass the Column 
            //value which you want to find
            recordIndex = ProductDataView.Find(1);
            if (recordIndex > -1)
            {
                Console.WriteLine("Row Found");
            }
