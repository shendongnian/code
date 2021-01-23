    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.IO;
    using System.Xml.Linq;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var xml = @"<ORM_O01>
                              <ORM_O01.PATIENT>
                               <PID>      
                                 <PID.18>
                                   <CX.1>SecondTestFin</CX.1>
                                 </PID.18>
                                 <PID.3>
                                    <CX.1>108</CX.1>
                                 </PID.3>
                               </PID>
                              </ORM_O01.PATIENT>
                              <MSH>
                                <MSH.9>
                                  <MSG.2>O01</MSG.2>
                                </MSH.9>
                                <MSH.6>
                                  <HD.1>13702</HD.1>
                                </MSH.6>
                              </MSH>
                            </ORM_O01>";
    
                var xDoc = XDocument.Parse(xml);
                
                var result = Sort(xDoc);
    
                Console.WriteLine(result.ToString());
    
                Console.Read();
            }
    
            private static XElement Sort(XElement element)
            {
                var xe = new XElement(element.Name, element.Elements().OrderBy(x => x.Name.ToString(), new SplitComparer()).Select(x => Sort(x)));
    
                if (!xe.HasElements)
                {
                    xe.Value = element.Value;
                }
    
                return xe;
            }
    
            private static XDocument Sort(XDocument file)
            {
                return new XDocument(Sort(file.Root));
            }
        }
    
        public class SplitComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                var partsOfX = x.Split('.');
    
                int firstNumber;
                if (partsOfX.Length > 1 && int.TryParse(partsOfX[1], out firstNumber))
                {
                    var secondNumber = Convert.ToInt32(y.Split('.')[1]);
    
                    return firstNumber.CompareTo(secondNumber);
                }
    
                return x.CompareTo(y);
            }
        }
    }
