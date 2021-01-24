     private void ParseXML(string value)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SwapDataSynapseResult));
            using (TextReader reader = new StringReader(value))
            {
                _result = serializer.Deserialize(reader) as SwapDataSynapseResult;
                _result.fwdRateDecimal = Decimal.Parse(_result.fwdRate, System.Globalization.NumberStyles.Float)
            }
        }
