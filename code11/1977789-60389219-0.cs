        public List<enumDetail> GetEnumMemberFromString(string enumName)
        {
            var enumFullName = $"Bamdad.PublicEnum.Enums+{enumName}";
            var assemblyList = AppDomain.CurrentDomain.GetAssemblies();
            Type type = null;
            foreach (var assembly in assemblyList)
            {
                type = assembly.GetType(enumFullName);
                if (type == null)
                    continue;
                if (type.IsEnum)
                    break;
            }
            if (type == null) return null;
            var valuesToNames = Enum.GetValues(type)
                    .Cast<object>()
                    .ToDictionary(q => Enum.GetName(type, q),q=> (int)q);
            var result = valuesToNames.Select(q => new enumDetail()
            {
                Name = q.Key,
                Value = q.Value,
                CustomName = type.GetMyCustomProperty(q.Key)?.ToString() ?? q.Key
            }).ToList();
            return result;
        }
