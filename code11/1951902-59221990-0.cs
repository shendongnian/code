public string SendMessage(string command, Action<string> Result = null) {
  string response  = "test";
  Result?.Invoke(response); // here
  return response;
}
This will fix your issue
