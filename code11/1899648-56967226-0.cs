`
//while ((k = st.ReadLine()) != null)
bool started = false;
foreach(var word in words){
    if(started && word == "FF")
    {
        break;
    }
    if(started)
    {
        grade.Add(int.Parse(word));
    }
    if(word == "FF")
    {
        started = true;
    }
}
`
