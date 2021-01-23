        public void TestNakedBigInt()
        {
            long foo = 12345;
            var result = connection.Query<long>("select @foo", new {foo}).Single();
            foo.IsEqualTo(result);
        }
    
        public void TestBigIntMember()
        {
            long foo = 12345;
            var result = connection.Query<WithBigInt>(@"
    declare @bar table(Value bigint)
    insert @bar values (@foo)
    select * from @bar", new {foo}).Single();
            result.Value.IsEqualTo(foo);
        }
        class WithBigInt
        {
            public long Value { get; set; }
        }
