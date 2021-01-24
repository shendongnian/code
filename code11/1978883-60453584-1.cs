		public static JObject ProtoReaderDeserilizer(List<CollectionFieldType> collectionMetadata, ProtoReader reader)
		{
			JObject obj = new JObject();
			while (reader.ReadFieldHeader() > 0)
			{
				var field = collectionMetadata[reader.FieldNumber - 1].Field;
				switch (reader.WireType)
				{
					case WireType.Variant:
						obj[field] = reader.ReadInt64();
						break;
					case WireType.String:
						var fieldType = collectionMetadata[reader.FieldNumber - 1].FieldType;
				
						switch (fieldType.ToLowerInvariant())
						{
							case "date":
								var tok1 = ProtoReader.StartSubItem(reader);
								reader.ReadFieldHeader();
								switch (reader.WireType)
								{
									case WireType.Variant:
										obj[field] = reader.ReadInt64();
										break;
									default:
										reader.ReadFieldHeader();
										break;
								}
								ProtoReader.EndSubItem(tok1, reader);
								break;
							case "datetime":
								obj[field] = BclHelpers.ReadDateTime(reader);
								break;
							case "decimal":
								obj[field] = BclHelpers.ReadDecimal(reader);
								break;
							case "guid":
								obj[field] = BclHelpers.ReadGuid(reader);
								break;
							case "string":
							default:
								if (!fieldType.StartsWith("["))
									obj[field] = reader.ReadString();
								else
								{
									var tok2 = ProtoReader.StartSubItem(reader);
									obj[field] = ProtoReaderDeserilizer(JsonConvert.DeserializeObject<List<CollectionFieldType>>(fieldType), reader);
									ProtoReader.EndSubItem(tok2, reader);
								}
								break;
						}
						break;
					case WireType.Fixed32:
						obj[field] = reader.ReadSingle();
						break;
					case WireType.Fixed64:
						obj[field] = reader.ReadDouble();
						break;
					case WireType.StartGroup:
						// one of 2 sub-object formats
						var tok = ProtoReader.StartSubItem(reader);
						obj[field] = ProtoReaderDeserilizer(JsonConvert.DeserializeObject<List<CollectionFieldType>>(collectionMetadata[reader.FieldNumber - 1].FieldType), reader);
						ProtoReader.EndSubItem(tok, reader);
						break;
					default:
						reader.SkipField();
						break;
				}
			}
			return obj;
		}
