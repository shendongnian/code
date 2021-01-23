    EXCEL.Range rango;
                rango = (EXCEL.Range)HojadetrabajoExcel.get_Range("AE13", "AK23");
                rango.Select();
          //      EXCEL.Pictures Lafoto = (EXCEL.Pictures).HojadetrabajoExcel.Pictures(System.Reflection.Missing.Value);
                EXCEL.Pictures Lafoto = HojadetrabajoExcel.Pictures(System.Reflection.Missing.Value);
                
                HojadetrabajoExcel.Shapes.AddPicture(@"D:\GENETICA HUMANA\Reportes\imagenes\" + Variables.nombreimagen,
                    Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue,
                    float.Parse(rango.Left.ToString()),float.Parse(rango.Top.ToString()), float.Parse(rango.Width.ToString()),
                    float.Parse(rango.Height.ToString()));
