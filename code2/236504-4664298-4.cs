	public class order
	{
		private Whatever whateverInstance;
		[XmlElement("ItemType")]
		public Whatever WhateverInstance
		{
			get { return whateverInstance; }
			set { whateverInstance = value; }
		}
		private Something somethingInstance;
		[XmlElement("ItemType")]
		public Something SomethingInstance
		{
			get { return somethingInstance; }
			set { somethingInstance = value; }
		}
	}
