    namespace ClassLibrary1
{
    using NFluent;
    using NUnit.Framework;
    [TestFixture]
    class MyNullableShould
    {
        [Test]
        public void operator_equals_btw_nullable_and_value_works()
        {
            var myNullable = new MyNullable<int>(1);
            Check.That(myNullable == 1).IsEqualTo(true);
            Check.That(myNullable == 2).IsEqualTo(false);
        }
        [Test]
        public void Can_be_comparedi_with_operator_equal_equals()
        {
            var myNullable = new MyNullable<int>(1);
            var myNullable2 = new MyNullable<int>(1);
            Check.That(myNullable == myNullable2).IsTrue();
            Check.That(myNullable == myNullable2).IsTrue();
            var myNullable3 = new MyNullable<int>(2);
            Check.That(myNullable == myNullable3).IsFalse();
        }
    }
