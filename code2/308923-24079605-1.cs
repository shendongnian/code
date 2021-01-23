		string RemoveDuplicateChars(string src, char[] dupes){	
			var sd = (char[])dupes.Clone();  
			Array.Sort(sd);
			
			var res = new StringBuilder(src.Length);
			
			for(int i = 0; i<src.Length; i++){
				if( i==0 || src[i]!=src[i-1] || Array.BinarySearch(sd,src[i])<0){
					res.Append(src[i]);	
				}
			}
			return res.ToString();
		}
