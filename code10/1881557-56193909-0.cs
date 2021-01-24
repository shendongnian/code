public class SqlServerDateTimeMapping : DateTimeTypeMapping {
    static MethodInfo s_getDateTimeSafeMethod = typeof( ContextDbDataReaderDecorator ).GetMethod( nameof( ContextDbDataReaderDecorator.GetDateTimeSafe ) );
    public SqlServerDateTimeMapping() : base( "DateTime", System.Data.DbType.DateTime ) {}
    protected SqlServerDateTimeMapping( RelationalTypeMappingParameters parameters ) : base( parameters ) {}
    public override string GenerateSqlLiteral( object value ) {
      if ( value is DateTime date ) {
        if ( date.Date != date ) {
          System.Diagnostics.Debug.Fail( "Time portions are not supported" );
        }
        return date.ToString( "yyyy-MM-dd" );
      }
      return base.GenerateSqlLiteral( value );
    }
    
    public override MethodInfo GetDataReaderMethod() {
      return s_getDateTimeSafeMethod;
    }
    public override RelationalTypeMapping Clone( in RelationalTypeMappingInfo mappingInfo ) => new SqlServerDateTimeMapping();
    public override RelationalTypeMapping Clone( string storeType, int? size ) => new SqlServerDateTimeMapping();
    public override CoreTypeMapping Clone( ValueConverter converter ) => new SqlServerDateTimeMapping();
  }
and the ContextDbDataReaderDecorator class I created looks like the following:
public class ContextDbDataReaderDecorator {
    public DbDataReader DbDataReader { get; }
    
    public ContextDbDataReaderDecorator( DbDataReader inner ) {
      DbDataReader = inner;
    }
    public static implicit operator DbDataReader( ContextDbDataReaderDecorator self )  => self.DbDataReader;
    public static implicit operator ContextDbDataReaderDecorator( DbDataReader other ) => new ContextDbDataReaderDecorator( other );
    public DateTime GetDateTimeSafe( int ordinal ) => (DbDataReader.GetValue( ordinal ) as DateTime?) ?? new DateTime( 3000, 1, 1 );
    public int GetIntSafe(int ordinal) => (DbDataReader.GetValue( ordinal ) as int?) ?? 0;
    public long GetLongSafe( int ordinal ) => (DbDataReader.GetValue( ordinal ) as long?) ?? 0;
    public float GetFloatSafe(int ordinal) => (DbDataReader.GetValue( ordinal ) as float?) ?? 0.0f;
  }
