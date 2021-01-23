    var rt = Ruby.CreateRuntime();
    var eng = rt.GetEngine("rb");
    eng.Execute(@"
                class Blocktest
                  def test(block)
                    block.Invoke('HELLO From IronRuby')
                  end
                end
                ");
    dynamic ruby = eng.Runtime.Globals;
    dynamic t = ruby.Blocktest.@new();
    t.test(new Action<string>(Console.WriteLine));
