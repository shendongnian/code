    public override ProblemCollection Check(Member member)
        {
            Method method = member as Method;
            if (method != null)
            {
                **if (method.Metrics.ClassCoupling > 20)**
                {
                    Resolution resolu = GetResolution(new string[] { method.ToString() });
                    Problems.Add(new Problem(resolu));
                }
            }
            return Problems;
        }
