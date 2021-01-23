        [TestMethod]
        public void ArraySegmentMagic()
        {
            var arr = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            var arrSegs = new ArraySegment<int>[3];
            arrSegs[0] = new ArraySegment<int>(arr, 0, 3);
            arrSegs[1] = new ArraySegment<int>(arr, 3, 3);
            arrSegs[2] = new ArraySegment<int>(arr, 6, 3);
            for (var i = 0; i < 3; i++)
            {
                var seg = arrSegs[i] as IList<int>;
                Console.Write(seg.GetType().Name.Substring(0, 12) + i);
                Console.Write(" {");
                for (var j = 0; j < seg.Count; j++)
                {
                    Console.Write("{0},", seg[j]);
                }
                Console.WriteLine("}");
            }
        }
