    string data = @"<data>
                      <LastUpdate></LastUpdate>
                      <AC1>12</AC1>
                      <AC2>13</AC2>
                      <AC3>14</AC3>
                      <Moter></Moter>
                      <Fan1></Fan1>
                      <Fan2></Fan2>
                      <TubeLight1></TubeLight1>
                      <TubeLight2></TubeLight2>
                      <Moter></Moter>
                      <CloseAll></CloseAll>
                </data>";
    
    XDocument xmlDoc = XDocument.Parse(data);
    
    var parsedData = from obj in xmlDoc.Descendants("data")
                     select new
                     {
                         LastUpdate = obj.Element("LastUpdate").Value,
                         AC1 = obj.Element("AC1").Value,
                         AC2 = obj.Element("AC1").Value,
                         ... and so on
                     }
