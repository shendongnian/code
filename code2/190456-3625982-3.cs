        public void WriteXml(XmlWriter writer)
        {
            writer.WriteRaw("<Model>" + this.Model + "</Model>");
            writer.WriteRaw("<Options>");
            writer.WriteRaw("<SeatFinish>" + this.SeatFinish + "</SeatFinish>");
            writer.WriteRaw("<Audio>" + this.Audio + "</Audio>");
            writer.WriteRaw("</Options>");
        }
        public void ReadXml(XmlReader reader) { ... }
    }
