	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Xml;
	namespace Test_20191203
	{
		public class LabResultItem
		{
			public string AnalyteCode { get; set; }
			public string AnalyteName { get; set; }
			public string Result { get; set; }
			public string ResultText { get; set; }
			public string Units { get; set; }
			public string LowRange { get; set; }
			public string HighRange { get; set; }
			public string Notes { get; set; }
		}
		public class Program
		{
			static void Main(string[] args)
			{
				string startProperty = nameof(LabResultItem.AnalyteCode);
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(input);
				List<LabResultItem> results = new List<LabResultItem>();
				LabResultItem currentItem = new LabResultItem();
				foreach (XmlNode node in doc.SelectSingleNode("/LabResults/LabResult/LabResultItems/LabResultItem").ChildNodes)
				{
					if (node.Name == startProperty)
					{
						results.Add(currentItem);
						currentItem = new LabResultItem();
					}
					var prop = typeof(LabResultItem).GetProperty(node.Name);
					if(prop == null)
					{
						throw new Exception($"Invalid node found in xml: '{node.Name}', property must be a part of {nameof(LabResultItem)}");
					}
					prop.SetValue(currentItem, node.InnerText, null);
				}
				foreach(var result in results)
				{
					// iterate through results
				}
			}
			const string input = @"<LabResults>
		<LabResult>
			<LabResultHeader>
				<TestCode>CDP</TestCode>
				<TestName>Comprehensive Diagnostic</TestName>
				<TestType>R</TestType>
				<ResultDate>2019-06-14T12:08:41-07:00</ResultDate>
				<ResultStatus>Done</ResultStatus>
				<DeviceID>XXXXXXYYYYYZZZZZ</DeviceID>
			</LabResultHeader>
			<LabResultItems>
				<LabResultItem>
					<AnalyteCode>HEM</AnalyteCode>
					<AnalyteName>HEM</AnalyteName>
					<Result>18.0</Result>
					<ResultText>0</ResultText>
					<AnalyteCode>LIP</AnalyteCode>
					<AnalyteName>LIP</AnalyteName>
					<Result>107.0</Result>
					<ResultText>0</ResultText>
					<AnalyteCode>ICT</AnalyteCode>
					<AnalyteName>ICT</AnalyteName>
					<Result>0.0</Result>
					<ResultText>0</ResultText>
					<AnalyteCode>ALB</AnalyteCode>
					<AnalyteName>Alb SerPl-mCnc</AnalyteName>
					<Result>37.0</Result>
					<Units>g/L</Units>
					<LowRange>25.0</LowRange>
					<HighRange>44.0</HighRange>
					<AnalyteCode>ALP</AnalyteCode>
					<AnalyteName>ALP SerPl-cCnc</AnalyteName>
					<Result>52.0</Result>
					<Units>U/L</Units>
					<LowRange>20.0</LowRange>
					<HighRange>150.0</HighRange>
					<AnalyteCode>ALT</AnalyteCode>
					<AnalyteName>ALT SerPl-cCnc</AnalyteName>
					<Result>54.0</Result>
					<Units>U/L</Units>
					<LowRange>10.0</LowRange>
					<HighRange>118.0</HighRange>
					<AnalyteCode>AMY</AnalyteCode>
					<AnalyteName>Amylase SerPl-cCnc</AnalyteName>
					<Result>320.0</Result>
					<Units>U/L</Units>
					<LowRange>200.0</LowRange>
					<HighRange>1200.0</HighRange>
					<AnalyteCode>TBIL</AnalyteCode>
					<AnalyteName>Bilirub SerPl-sCnc</AnalyteName>
					<Result>4.0</Result>
					<Units>umol/L</Units>
					<LowRange>2.0</LowRange>
					<HighRange>10.0</HighRange>
					<AnalyteCode>BUN</AnalyteCode>
					<AnalyteName>BUN SerPl-sCnc</AnalyteName>
					<Result>4.8</Result>
					<Units>mmol/L</Units>
					<LowRange>2.5</LowRange>
					<HighRange>8.9</HighRange>
					<AnalyteCode>CA</AnalyteCode>
					<AnalyteName>Calcium SerPl-sCnc</AnalyteName>
					<Result>2.87</Result>
					<Units>mmol/L</Units>
					<LowRange>2.15</LowRange>
					<HighRange>2.95</HighRange>
					<AnalyteCode>PHOS</AnalyteCode>
					<AnalyteName>Phosphate SerPl-sCnc</AnalyteName>
					<ResultText>2.38 *</ResultText>
					<Units>mmol/L</Units>
					<LowRange>0.94</LowRange>
					<HighRange>2.13</HighRange>
					<Notes>H</Notes>
					<AnalyteCode>CRE</AnalyteCode>
					<AnalyteName>Creat SerPl-sCnc</AnalyteName>
					<Result>57.0</Result>
					<Units>umol/L</Units>
					<LowRange>27.0</LowRange>
					<HighRange>124.0</HighRange>
					<AnalyteCode>GLU</AnalyteCode>
					<AnalyteName>Glucose SerPl-sCnc</AnalyteName>
					<ResultText>6.2 *</ResultText>
					<Units>mmol/L</Units>
					<LowRange>3.3</LowRange>
					<HighRange>6.1</HighRange>
					<Notes>H</Notes>
					<AnalyteCode>NA+</AnalyteCode>
					<AnalyteName>Sodium SerPl-sCnc</AnalyteName>
					<Result>149.0</Result>
					<Units>mmol/L</Units>
					<LowRange>138.0</LowRange>
					<HighRange>160.0</HighRange>
					<AnalyteCode>K+</AnalyteCode>
					<AnalyteName>Potassium SerPl-sCnc</AnalyteName>
					<Result>4.7</Result>
					<Units>mmol/L</Units>
					<LowRange>3.7</LowRange>
					<HighRange>5.8</HighRange>
					<AnalyteCode>TP</AnalyteCode>
					<AnalyteName>Prot SerPl-mCnc</AnalyteName>
					<Result>58.0</Result>
					<Units>g/L</Units>
					<LowRange>54.0</LowRange>
					<HighRange>82.0</HighRange>
					<AnalyteCode>GLOB</AnalyteCode>
					<AnalyteName>Globulin SerPl Calc-mCnc</AnalyteName>
					<ResultText>21 *</ResultText>
					<Units>g/L</Units>
					<LowRange>23.0</LowRange>
					<HighRange>52.0</HighRange>
					<Notes>L</Notes>
				</LabResultItem>
			</LabResultItems>
		</LabResult>
	</LabResults>";
		}
	}
