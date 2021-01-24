// Portions of this code adopted from Fare, itself adopted from brics
// original copyright notice included.
// This is the only file this applies to.
/*
 * dk.brics.automaton
 * 
 * Copyright (c) 2001-2011 Anders Moeller
 * All rights reserved.
 * http://github.com/moodmosaic/Fare/
 * Original Java code:
 * http://www.brics.dk/automaton/
 * 
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 * 3. The name of the author may not be used to endorse or promote products
 *    derived from this software without specific prior written permission.
 * 
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 * IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 * IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
 * INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 * DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 * THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 * THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
public static FA _Determinize(FA fa, IProgress<FAProgress> progress = null)
{
    if (null != progress)
        progress.Report(new FAProgress(FAStatus.DfaTransform, 0));
    var p = new HashSet<int>();
    var closure = new List<FA>();
    fa.FillClosure(closure);
    for(int ic=closure.Count,i=0;i<ic;++i)
    {
        var ffa = closure[i];
        p.Add(0);
        foreach (var t in ffa.InputTransitions)
        {
            p.Add(t.Key.Key);
            if (t.Key.Value < 0x10ffff)
            {
                p.Add((t.Key.Value + 1));
            }
        }
    }
    var points = new int[p.Count];
    p.CopyTo(points, 0);
    Array.Sort(points);
            
    var comparer = _SetComparer.Default;
    var sets = new Dictionary<ICollection<FA>, ICollection<FA>>(comparer);
    var working = new Queue<ICollection<FA>>();
    var dfaMap = new Dictionary<ICollection<FA>, FA>(comparer);
    var initial = fa.FillEpsilonClosure();
    sets.Add(initial, initial);
    working.Enqueue(initial);
    var result = new FA();
    foreach(var afa in initial)
    {
        if(afa.IsAccepting)
        {
            result.IsAccepting = true;
            result.AcceptSymbol = afa.AcceptSymbol;
            break;
        }
    }
    dfaMap.Add(initial, result);
    var j = 1;
    while (working.Count > 0)
    {
        ICollection<FA> s = working.Dequeue();
        var ecs = FillEpsilonClosure(s);
        FA dfa;
        dfaMap.TryGetValue(s, out dfa);
        foreach (FA q in ecs)
        {
            if (q.IsAccepting)
            {
                dfa.IsAccepting = true;
                dfa.AcceptSymbol = q.AcceptSymbol;
                break;
            }
        }
        for (var i = 0; i < points.Length; i++)
        {
            var set = new HashSet<FA>();
            foreach (FA c in ecs)
            {
                foreach (var trns in c.InputTransitions)
                {
                    if (trns.Key.Key <= points[i] && points[i] <= trns.Key.Value)
                    {
                        foreach (var efa in trns.Value.FillEpsilonClosure())
                            set.Add(trns.Value);
                    }
                }
            }
            if (!sets.ContainsKey(set))
            {
                sets.Add(set, set);
                working.Enqueue(set);
                dfaMap.Add(set, new FA());
            }
            FA dst;
            dfaMap.TryGetValue(set, out dst);
            int first = points[i];
            int last;
            if (i + 1 < points.Length)
                last = (points[i + 1] - 1);
            else
                last = 0x10ffff;
            dfa.InputTransitions.Add(new KeyValuePair<int, int>(first, last), dst);
        }
        if (null != progress)
            progress.Report(new FAProgress(FAStatus.DfaTransform, j));
        ++j;
    }
    // remove dead transitions
    foreach(var ffa in result.FillClosure())
    {
        var itrns = new List<KeyValuePair<KeyValuePair<int, int>, FA>>(ffa.InputTransitions);
        ffa.InputTransitions.Clear();
        foreach(var trns in itrns)
        {
            if(null!=trns.Value.FirstAcceptingState)
            {
                ffa.InputTransitions.Add(trns.Key, trns.Value);
            }
        }
        if (null != progress)
            progress.Report(new FAProgress(FAStatus.DfaTransform, j));
        ++j;
    }
        return result;
}
