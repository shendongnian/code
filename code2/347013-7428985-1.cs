    class ZoneCollection : IList<Zone>, ICustomTypeDescriptor
    {
        //  Must be defined as an IList and not a List for NHibernate to save correctly
        private IList<Zone> _inner;
        public ZoneCollection()
        {
            _inner = new List<Zone>();
        }
        public int IndexOf(Zone item)
        {
            return _inner.IndexOf(item);
        }
        // ...
    }
    <component name="Zones" access="nosetter.camelcase-underscore">
      <bag name="_inner" access="field" cascade="all-delete-orphan">
        <key>
          <column name="Intersection_id" />
        </key>
        <one-to-many class="EMTRAC.Zones.Zone, EMTRAC_v3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"/>
      </bag>
    </component>
