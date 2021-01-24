    List<SpannableString> spannableStringList = new List<SpannableString>();            
    CustomTypefaceSpan customTypefaceSpan = new CustomTypefaceSpan(typeface);
    var spannableString1 = new SpannableString("Hello");
    spannableString1.SetSpan(customTypefaceSpan, 0, spannableString1.Length(), SpanTypes.ExclusiveExclusive);
    spannableString1.SetSpan(new ForegroundColorSpan(Color.Green), 0, spannableString1.Length(), SpanTypes.InclusiveInclusive);
    var spannableString2 = new SpannableString("Leo");
    spannableString2.SetSpan(new ForegroundColorSpan(Color.Red),0, spannableString2.Length(), SpanTypes.InclusiveInclusive);
    spannableStringList.Add(spannableString1);
    spannableStringList.Add(spannableString2);
    var ssBuilder= new SpannableStringBuilder();
    foreach (var item in spannableStringList)
      {
         ssBuilder.Append(item);
      }
    textView.SetText(ssBuilder, BufferType.Spannable);
