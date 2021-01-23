    using System;
    using System.Collections;
    using System.Collections.Generic;
    using NUnit.Framework;
    [TestFixture]
    public class StringExtensionMethodsTests
    {
        [TestCaseSource(typeof(StringExtensionMethodsTests_Remove_Tests))]
        public void Remove(string targetString, IEnumerable<char> removeCharacters, string expected)
        {
            string actual = StringExtensionMethods.Remove(targetString, removeCharacters);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [TestCaseSource(typeof(StringExtensionMethodsTests_Remove_ParameterValidation_Tests))]
        public void Remove_ParameterValidation(string targetString, IEnumerable<char> removeCharacters)
        {
            Assert.Throws<ArgumentNullException>(() => StringExtensionMethods.Remove(targetString, removeCharacters));
        }
    }
    internal class StringExtensionMethodsTests_Remove_Tests : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TestCaseData("My name @is ,Wan.;'; Wan", new char[] { '@', ',', '.', ';', '\'' }, "My name is Wan Wan").SetName("StringUsingCharArray");
            yield return new TestCaseData("My name @is ,Wan.;'; Wan", new HashSet<char> { '@', ',', '.', ';', '\'' }, "My name is Wan Wan").SetName("StringUsingISetCollection");
            yield return new TestCaseData(string.Empty, new char[1], string.Empty).SetName("EmptyStringNoReplacementCharactersYieldsEmptyString");
            yield return new TestCaseData(string.Empty, new char[] { 'A', 'B', 'C' }, string.Empty).SetName("EmptyStringReplacementCharsYieldsEmptyString");
            yield return new TestCaseData("No replacement characters", new char[1], "No replacement characters").SetName("StringNoReplacementCharactersYieldsString");
            yield return new TestCaseData("No characters will be replaced", new char[] { 'Z' }, "No characters will be replaced").SetName("StringNonExistantReplacementCharactersYieldsString");
            yield return new TestCaseData("AaBbCc", new char[] { 'a', 'C' }, "ABbc").SetName("CaseSensitivityReplacements");
            yield return new TestCaseData("ABC", new char[] { 'A', 'B', 'C' }, string.Empty).SetName("AllCharactersRemoved");
            yield return new TestCaseData("AABBBBBBCC", new char[] { 'A', 'B', 'C' }, string.Empty).SetName("AllCharactersRemovedMultiple");
            yield return new TestCaseData("Test That They Didn't Attempt To Use .Except() which returns distinct characters", new char[] { '(', ')' }, "Test That They Didn't Attempt To Use .Except which returns distinct characters").SetName("ValidateTheStringIsNotJustDistinctCharacters");
        }
    }
    internal class StringExtensionMethodsTests_Remove_ParameterValidation_Tests : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new TestCaseData(null, null);
            yield return new TestCaseData("valid string", null);
            yield return new TestCaseData(null, new char[1]);
        }
    }
