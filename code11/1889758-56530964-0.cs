        override public DbType DbType {
            get {
                return GetMetaTypeOnly().DbType;
            }
            set {
                MetaType metatype = _metaType;
                if ((null == metatype) || (metatype.DbType != value) ||
                        // SQLBU 504029: Two special datetime cases for backward compat
                        //  DbType.Date and DbType.Time should always be treated as setting DbType.DateTime instead
                        value == DbType.Date ||
                        value == DbType.Time) {
                    PropertyTypeChanging();
                    _metaType = MetaType.GetMetaTypeFromDbType(value);
                }
            }
        }
