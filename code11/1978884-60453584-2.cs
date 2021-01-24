		public static void ProtoSerializer(ProtoWriter writer, JObject obj, List<CollectionFieldType> collectionMetadata, string name)
		{
			int i = 1;
			if (obj == null)
			{
				throw new FormatException($"Collection {name} has invalid object defined in its field types. Ensure your collection schema and field times schema match.");
			}
			foreach (var field in collectionMetadata)
			{
				string exType = string.Empty;
				if (obj.TryGetValue(field.Field, out var fieldToken))
					exType = SerializeField(writer, name, i, field, exType, fieldToken);
				if (!string.IsNullOrEmpty(exType))
					throw new FormatException($"Collection: {name}, Field: {field.Field} invalid {exType} value: {fieldToken.ToString()}");
				i++;
			}
		}
		private static void SerializeDefaultValue(ProtoWriter writer, int i, CollectionFieldType field)
		{
			switch (field.FieldType.ToLowerInvariant())
			{
				case "bool":
					ProtoWriter.WriteFieldHeader(i, WireType.Variant, writer);
					ProtoWriter.WriteBoolean(default, writer);
					break;
				case "byte":
					ProtoWriter.WriteFieldHeader(i, WireType.Variant, writer);
					ProtoWriter.WriteByte(default, writer);
					break;
				case "sbyte":
					ProtoWriter.WriteFieldHeader(i, WireType.Variant, writer);
					ProtoWriter.WriteSByte(default, writer);
					break;
				case "decimal":
					ProtoWriter.WriteFieldHeader(i, WireType.Fixed64, writer);
					BclHelpers.WriteDecimal(default, writer);
					break;
				case "double":
					ProtoWriter.WriteFieldHeader(i, WireType.Fixed64, writer);
					ProtoWriter.WriteDouble(default, writer);
					break;
				case "float":
					ProtoWriter.WriteFieldHeader(i, WireType.Fixed64, writer);
					ProtoWriter.WriteDouble(default, writer);
					break;
				case "int":
					ProtoWriter.WriteFieldHeader(i, WireType.Variant, writer);
					ProtoWriter.WriteInt32(default, writer);
					break;
				case "enum":
					ProtoWriter.WriteFieldHeader(i, WireType.Variant, writer);
					ProtoWriter.WriteInt32(default, writer);
					break;
				case "long":
					ProtoWriter.WriteFieldHeader(i, WireType.Fixed64, writer);
					ProtoWriter.WriteInt64(default, writer);
					break;
				case "short":
					ProtoWriter.WriteFieldHeader(i, WireType.Fixed32, writer);
					ProtoWriter.WriteInt16(default, writer);
					break;
				case "date":
					ProtoWriter.WriteFieldHeader(i, WireType.String, writer);
					var dateToken = ProtoWriter.StartSubItem(field, writer);
					ProtoWriter.WriteFieldHeader(i, WireType.Variant, writer);
					ProtoWriter.WriteInt32(default, writer);
					ProtoWriter.EndSubItem(dateToken, writer);
					break;
				case "datetime":
					ProtoWriter.WriteFieldHeader(i, WireType.String, writer);
					BclHelpers.WriteDateTime(default, writer);
					break;
				case "guid":
					ProtoWriter.WriteFieldHeader(i, WireType.String, writer);
					BclHelpers.WriteGuid(default, writer);
					break;
				case "char":
				case "string":
				default:
					ProtoWriter.WriteFieldHeader(i, WireType.String, writer);
					ProtoWriter.WriteString(string.Empty, writer);
					break;
			}
		}
		private static string SerializeField(ProtoWriter writer, string name, int i, CollectionFieldType field, string exType, JToken fieldToken)
		{
			switch (field.FieldType.ToLowerInvariant())
			{
				case "bool":
					if (bool.TryParse(fieldToken.ToString(), out bool boolVal))
					{
						ProtoWriter.WriteFieldHeader(i, WireType.Variant, writer);
						ProtoWriter.WriteBoolean(boolVal, writer);
					}
					else
					{
						exType = "bool";
					}
					break;
				case "byte":
					if (byte.TryParse(fieldToken.ToString(), out byte byteVal))
					{
						ProtoWriter.WriteFieldHeader(i, WireType.Variant, writer);
						ProtoWriter.WriteByte(byteVal, writer);
					}
					else
					{
						exType = "byte";
					}
					break;
				case "sbyte":
					if (sbyte.TryParse(fieldToken.ToString(), out sbyte sbyteVal))
					{
						ProtoWriter.WriteFieldHeader(i, WireType.Variant, writer);
						ProtoWriter.WriteSByte(sbyteVal, writer);
					}
					else
					{
						exType = "sbyte";
					}
					break;
				case "decimal":
					if (decimal.TryParse(fieldToken.ToString(), out decimal decimalVal))
					{
						ProtoWriter.WriteFieldHeader(i, WireType.Fixed64, writer);
						BclHelpers.WriteDecimal(decimalVal, writer);
					}
					else
					{
						exType = "decimal";
					}
					break;
				case "double":
					if (double.TryParse(fieldToken.ToString(), out double doubleVal))
					{
						ProtoWriter.WriteFieldHeader(i, WireType.Fixed64, writer);
						ProtoWriter.WriteDouble(doubleVal, writer);
					}
					else
					{
						exType = "double";
					}
					break;
				case "float":
					if (float.TryParse(fieldToken.ToString(), out float floatVal))
					{
						ProtoWriter.WriteFieldHeader(i, WireType.Fixed64, writer);
						ProtoWriter.WriteDouble(floatVal, writer);
					}
					else
					{
						exType = "float";
					}
					break;
				case "enum":
				case "int":
					if (int.TryParse(fieldToken.ToString(), out int intVal))
					{
						ProtoWriter.WriteFieldHeader(i, WireType.Variant, writer);
						ProtoWriter.WriteInt32(intVal, writer);
					}
					else
					{
						exType = "int";
					}
					break;
				case "long":
					if (long.TryParse(fieldToken.ToString(), out long longVal))
					{
						ProtoWriter.WriteFieldHeader(i, WireType.Fixed64, writer);
						ProtoWriter.WriteInt64(longVal, writer);
					}
					else
					{
						exType = "long";
					}
					break;
				case "short":
					if (short.TryParse(fieldToken.ToString(), out short shortVal))
					{
						ProtoWriter.WriteFieldHeader(i, WireType.Fixed32, writer);
						ProtoWriter.WriteInt16(shortVal, writer);
					}
					else
					{
						exType = "short";
					}
					break;
				case "date":
					ProtoWriter.WriteFieldHeader(i, WireType.String, writer);
					var dateToken = ProtoWriter.StartSubItem(fieldToken, writer);
					if (int.TryParse(fieldToken.ToString(), out int dateVal))
					{
						ProtoWriter.WriteFieldHeader(i, WireType.Variant, writer);
						ProtoWriter.WriteInt32(dateVal, writer);
					}
					else
					{
						exType = "date";
					}
					ProtoWriter.EndSubItem(dateToken, writer);
					break;
				case "datetime":
					if (fieldToken.Type == JTokenType.Date)
					{
						ProtoWriter.WriteFieldHeader(i, WireType.String, writer);
						BclHelpers.WriteDateTime((DateTime)fieldToken, writer);
					}
					else
					{
						exType = "DateTime";
					}
					break;
				case "guid":
					if (Guid.TryParse(fieldToken.ToString(), out Guid guidVal))
					{
						ProtoWriter.WriteFieldHeader(i, WireType.String, writer);
						BclHelpers.WriteGuid(guidVal, writer);
					}
					else
					{
						exType = "guid";
					}
					break;
				case "char":
				case "string":
				default:
					if (field.FieldType.StartsWith("["))
					{
						ProtoWriter.WriteFieldHeader(i, WireType.String, writer);
						var token = ProtoWriter.StartSubItem(fieldToken, writer);
						ProtoSerializer(writer, fieldToken as JObject, JsonConvert.DeserializeObject<List<CollectionFieldType>>(field.FieldType), name);
						ProtoWriter.EndSubItem(token, writer);
					}
					else
					{
						ProtoWriter.WriteFieldHeader(i, WireType.String, writer);
						ProtoWriter.WriteString(fieldToken.ToString(), writer);
					}
					break;
			}
			return exType;
		}
