        public static IEnumerable<EnumDto> GetOptions<TEnum>() where TEnum : Enum
        {
            var type = typeof(TEnum);
            switch (type)
            {
                case Type _ when type == typeof(Gender):
                    return _gender.Value;
                default:
                    return _maritalStatus.Value;
            }
        }
