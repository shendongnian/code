    public byte[] ConvierteAXLSX(string cuerpo)
            {
                File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "viejo.xls", Convert.FromBase64String(cuerpo));
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(AppDomain.CurrentDomain.BaseDirectory + "viejo.xls");
                workbook.SaveToFile(AppDomain.CurrentDomain.BaseDirectory + "nuevo.xlsx", ExcelVersion.Version2013);
                byte[] fileContent = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "nuevo.xlsx");
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "viejo.xls");
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "nuevo.xlsx");
                return fileContent;
            }
